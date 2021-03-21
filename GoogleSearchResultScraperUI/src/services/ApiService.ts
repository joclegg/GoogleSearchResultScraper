import {SearchRequest} from "../types/types";
import axios from "axios";
import {config} from "../config";

/* istanbul ignore next */
export default class ApiService {
  private endpoints = {
    searchResults:"",
  };

  constructor() {
    const domain = process.env.NODE_ENV === "development" ? config.LOCAL_DOMAIN_URL : "";
    this.endpoints.searchResults = domain + config.API_PREFIX + config.API_GET_SEARCHRESULTS;
  }

  getSearchResults(request: SearchRequest): Promise<string> {
    return axios
      .post(this.endpoints.searchResults,{
        searchTerm: request.searchTerm,
        url: request.url
      })
      .then((response) => response.data)
      .catch((error) => {
        throw new Error(error);
      });
  }
}
