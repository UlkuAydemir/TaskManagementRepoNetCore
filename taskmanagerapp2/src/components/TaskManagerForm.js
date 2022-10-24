import React, { useState, useEffect } from "react";
import { Grid, TextField, withStyles, FormControl, InputLabel, Select, MenuItem, Button, FormHelperText } from "@material-ui/core";
import useForm from "./useForm";
import { connect } from "react-redux";
import * as actions from "../actions/taskManager";
import { useToasts } from "react-toast-notifications";
import { DatePicker } from '@material-ui/pickers'




const styles = theme => ({
    root: {
        '& .MuiTextField-root': {
            margin: theme.spacing(1),
            minWidth: 230,
        }
    },
    formControl: {
        margin: theme.spacing(1),
        minWidth: 230,
    },
    smMargin: {
        margin: theme.spacing(1)
    }
})

const initialFieldValues = {
    taskTitle: '',
    taskDescription: '',
    startTime: '',
    createTime: '',
    endTime: '',
    isCompleted: ''
}

const TaskManagerForm = ({ classes, ...props }) => {

    //toast msg.
    const { addToast } = useToasts()

    //validate()
    //validate({taskTitle:'create'})
    const validate = (fieldValues = values) => {
        let temp = { ...errors }
        if ('taskTitle' in fieldValues)
            temp.taskTitle = fieldValues.taskTitle ? "" : "This field is required."
        if ('taskDecription' in fieldValues)
            temp.taskDecription = fieldValues.taskDecription ? "" : "This field is required."
        setErrors({
            ...temp
        })

        if (fieldValues == values)
            return Object.values(temp).every(x => x == "")
    }

    const {
        values,
        setValues,
        errors,
        setErrors,
        handleInputChange,
        resetForm
    } = useForm(initialFieldValues, validate, props.setCurrentId)

    //material-ui select
    const inputLabel = React.useRef(null);
    const [labelWidth, setLabelWidth] = React.useState(0);
    React.useEffect(() => {
        setLabelWidth(0);
    }, []);

    const handleSubmit = e => {
        e.preventDefault()
        if (validate()) {
            const onSuccess = () => {
                resetForm()
                addToast("Submitted successfully", { appearance: 'success' })
            }
            var today = new Date();

            if (props.currentId == 0){
                values.createTime = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();
                values.endTime =new Date(new Date('1900-01-01'));
                values.startTime =new Date(new Date('1900-01-01'));
                values.isCompleted = false;
                props.createTask(values, onSuccess)
            }
            else{
               
                values.startTime = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();
                props.updateTask(props.currentId, values, onSuccess)
            }
                
        }
    }

    useEffect(() => {
        if (props.currentId != 0) {
            setValues({
                ...props.taskList.find(x => x.id == props.currentId)
            })
            setErrors({})
        }
    }, [props.currentId])

    return (
        <form autoComplete="off" noValidate className={classes.root} onSubmit={handleSubmit}>
            <Grid container>
                
                <Grid item xs={6}>

                    <TextField
                        name="taskTitle"
                        variant="outlined"
                        label="Task Title"
                        value={values.taskTitle}
                        onChange={handleInputChange}
                        {...(errors.taskTitle && { error: true, helperText: errors.taskTitle })}
                    />
                    <TextField
                        name="taskDescription"
                        variant="outlined"
                        label="Task Description"
                        value={values.taskDescription}
                        onChange={handleInputChange}
                    />
                    <div>
                        <Button
                            variant="contained"
                            color="primary"
                            type="submit"
                            className={classes.smMargin}
                        >
                            Submit
                        </Button>
                        <Button
                            variant="contained"
                            className={classes.smMargin}
                            onClick={resetForm}
                        >
                            Reset
                        </Button>
                    </div>
                </Grid>
            </Grid>
        </form>
    );
}


const mapStateToProps = state => ({
    taskList: state.taskManager.list
})

const mapActionToProps = {
    createTask: actions.create,
    updateTask: actions.update
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(TaskManagerForm));