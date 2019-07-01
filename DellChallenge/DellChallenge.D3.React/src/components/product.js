import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import Validation from "../validation";

class Product extends Component {
  constructor(props) {
    super(props);
    this.state = {
      Id: props.Id
    };
    this.handleInputChange = this.handleInputChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  
  componentDidMount() {
    fetch("http://localhost:5000/api/products/"+this.state.id)
      .then(res => res.json())
      .then(
        result => {
          this.setState({
            Id: result.Id,
			Name: result.Name,
			Category: result.Category,
          });
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        error => {
          this.setState({
            isLoaded: true,
            error
          });
        }
      );
  }
  
  handleSubmit = event => {
    event.preventDefault();
    let postData = {
	  Id: this.state.Id,
      Name: this.state.Name,
      Category: this.state.Category
    };

    fetch("http://localhost:5000/api/products/"+this.state.Id, {
      method: "PUT",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      mode: "cors",
      body: JSON.stringify(postData)
    })
    .then(res => res.json())
    .then(this.props.history.push('/products'))
    .catch(err => console.log(err));
  };

  handleInputChange = event => {
    const target = event.target;
    const value = target.type === "checkbox" ? target.checked : target.value;
    const name = target.name;

    this.setState({
      [name]: value
    });
  };

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <h4>Add new Product</h4>
        <div className="form-group">
          <label className="control-label" htmlFor="Name">
            Name
          </label>
          <input
            className="form-control"
            type="text"
            id="Name"
            name="Name"
            onChange={this.handleInputChange}
            value={this.state.Name}
          />
          <span
            className="text-danger field-validation-valid"
            data-valmsg-for="Name"
            data-valmsg-replace="true"
          />
        </div>
        <div className="form-group">
          <label className="control-label" htmlFor="Category">
            Category
          </label>
          <input
            className="form-control"
            type="text"
            id="Category"
            name="Category"
            onChange={this.handleInputChange}
            value={this.state.Category}
          />
          <span
            className="text-danger field-validation-valid"
            data-valmsg-for="Category"
            data-valmsg-replace="true"
          />
        </div>
        <div className="form-group">
          <button className="btn btn-primary">Submit</button>
        </div>
        <Validation />
      </form>
    );
  }
}

export default Product;
