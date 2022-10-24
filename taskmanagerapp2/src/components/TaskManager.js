import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/taskManager";
import { Grid, Paper, TableContainer, Table, TableHead, TableRow, TableCell, TableBody, withStyles, ButtonGroup, Button, IconButton } from "@material-ui/core";
import TaskManagerForm from "./TaskManagerForm";
import EditIcon from "@material-ui/icons/Edit";
import DeleteIcon from "@material-ui/icons/Delete";
import { useToasts } from "react-toast-notifications";
import { Check, PlayCircleFilled } from "@material-ui/icons";



const styles = theme => ({
    root: {
        "& .MuiTableCell-head": {
            fontSize: "1.25rem"
        }
    },
    paper: {
        margin: theme.spacing(2),
        padding: theme.spacing(2)
    }
})

const TaskManager = ({ classes, ...props }) => {
    const [currentId, setCurrentId] = useState(0)

    useEffect(() => {
        props.fetchAllTask()
    }, [])//componentDidMount
    
    //toast msg.
    const { addToast } = useToasts()
   
    const onDelete = id => {
        if (window.confirm('Are you sure to delete this record?'))
            props.deleteTask(id,()=>addToast("Deleted successfully", { appearance: 'info' }))
    }
    const onStart = record => {
        if (window.confirm('Are you sure to start this record?'))
        {
            record.startTime = Date.now();
            props.updateTask(record,()=>addToast("Started successfully", { appearance: 'info' }))
        }
            
    }
    return (
        <Paper className={classes.paper} elevation={3}>
            <Grid container>
                <Grid item xs={12}>
                    <TaskManagerForm {...({ currentId, setCurrentId })} />
                </Grid>
                <Grid item xs={12}>
                    <TableContainer>
                        <Table>
                            <TableHead className={classes.root}>
                                <TableRow>
                                    <TableCell>Task Title</TableCell>
                                    <TableCell>Task Description</TableCell>
                                    <TableCell>Start Date</TableCell>
                                    <TableCell>End Date</TableCell>
                                    <TableCell>Create Date</TableCell>
                                    <TableCell>IsCompleted</TableCell>
                                    <TableCell></TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {
                                    props.taskList.map((record, index) => {
                                        return (<TableRow key={index} hover>
                                            <TableCell>{record.taskTitle}</TableCell>
                                            <TableCell>{record.taskDescription}</TableCell>
                                            <TableCell>{record.startTime}</TableCell>
                                            <TableCell>{record.endTime}</TableCell>
                                            <TableCell>{record.createTime}</TableCell>
                                            <TableCell>{record.isCompleted}</TableCell>
                                            <TableCell>
                                                <ButtonGroup variant="text">
                                                <Button><PlayCircleFilled color="action"
                                                    onClick={() => onStart(record)} /></Button>
                                                    <Button><EditIcon color="primary"
                                                        onClick={() => { setCurrentId(record.id) }} /></Button>
                                                    <Button><DeleteIcon color="secondary"
                                                        onClick={() => onDelete(record.id)} /></Button>
                                                    
                                                </ButtonGroup>
                                            </TableCell>
                                        </TableRow>)
                                    })
                                }
                            </TableBody>
                        </Table>
                    </TableContainer>
                </Grid>
            </Grid>
        </Paper>
    );
}


const mapStateToProps = state => ({
    taskList: state.taskManager.list
})

const mapActionToProps = {
    fetchAllTask: actions.fetchAll,
    deleteTask: actions.Delete,
    updateTask: actions.update
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(TaskManager));