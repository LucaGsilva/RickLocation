import Axios from 'axios';

export default class RickLocationService {

  async createRick(dado) {
    return await Axios.post("api/rick", dado);

  }

  async getRick(id) {
    return await Axios.get(`api/rick/${id}`);
  }

  async getRicks() {
    return await Axios.get("api/rick");
  }


  async createTravel(dado) {
    return await Axios.post("api/travel", dado);
  }

  async getTravels(id) {
    return await Axios.get(`api/rick/travels/${id}`);
  }

}
