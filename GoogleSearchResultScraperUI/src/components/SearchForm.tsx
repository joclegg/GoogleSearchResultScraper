import React from 'react';
import { Formik, Form } from "formik";
import { TextField, Button } from '@material-ui/core';
import ApiService from "../services/ApiService";
import { SearchRequest, SearchResults } from '../types/types';

export default class SearchForm extends React.Component<{}, SearchResults> {
  private apiService: ApiService;

  constructor(props: {}){
    super(props)
    this.state = {
      result: ""
    }
    this.apiService = new ApiService();
  }

  onSubmit =  async (values: SearchRequest) => {
    let response = await this.apiService.getSearchResults(values)
    this.setState({ result: response })
  }

  render(){
    return (
          <div>
            <Formik
              initialValues={{ searchTerm: "", url: "" }}
              onSubmit={values => {
                this.onSubmit(values)
              }}>
              {({ values, handleChange, handleBlur }) => (
                <Form>
                  <div>
                    <TextField
                      placeholder="Search Term"
                      name="searchTerm"
                      value={values.searchTerm}
                      onChange={handleChange}
                      onBlur={handleBlur} />
                  </div>
                  <div>
                    <TextField
                      placeholder="Url"
                      name="url"
                      value={values.url}
                      onChange={handleChange}
                      onBlur={handleBlur} />
                  </div>
                  <Button  color="primary" type="submit">Submit</Button>
                </Form>
              )}
            </Formik>
            <div>
              <h2>{ this.state.result }</h2>
            </div>
          </div>
        )
  }
}
