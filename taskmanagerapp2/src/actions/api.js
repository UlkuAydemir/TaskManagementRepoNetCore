import axios from "axios";

const baseUrl = "http://localhost:8001/api/"



export default {

    taskManager(url = baseUrl + 'task/') {
        axios.defaults.headers.get['Access-Control-Allow-Origin'] = '*';
        axios.defaults.headers.get['Access-Control-Allow-Credentials'] = 'true';
        axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
        axios.defaults.headers.post['Access-Control-Allow-Credentials'] = 'true';
        axios.defaults.headers.put['Access-Control-Allow-Origin'] = '*';
        axios.defaults.headers.put['Access-Control-Allow-Credentials'] = 'true';
        return {
            fetchAll: () => axios.get(url),
            fetchById: id => axios.get(url + id),
            create: newRecord => axios.post(url, newRecord),
            update: (id, updateRecord) => axios.put(url, updateRecord),
            delete: id => axios.delete(url + id)
        }
    }
}