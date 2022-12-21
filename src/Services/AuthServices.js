import AxiosServices from "./AxiosServices";
import Configuration from "../Configurations/Configuration";

const axiosService = new AxiosServices();

export default class AuthServices {

    register(data){
        return axiosService.post(Configuration.register, data, false)
    }

    login(data){
        return axiosService.post(Configuration.login, data, false)
    }

}