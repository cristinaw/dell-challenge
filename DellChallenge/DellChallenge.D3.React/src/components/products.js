import React, { Component } from "react";
import Validation from "../validation";
import Product from "../components/product";

class ProductList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: []
    };
	
	
  }

  componentDidMount() {
    fetch("http://localhost:5000/api/products")
      .then(res => res.json())
      .then(
        result => {
          this.setState({
            isLoaded: true,
            items: result
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
  
  deleteProduct(productId) {
    const { items } = this.state;

    fetch("http://localhost:5000/api/products/delete/"+productId, {
      method: "DELETE",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json"
      },
      mode: "cors",
    })
    .then(res => res.json())
	.then(this.props.history.push('/products'))
    .catch(err => console.log(err));
  
  redirectToEdit = (productId) => {
    this.props.history.push("/product/" + id)
  }

  render() {
    const { error, isLoaded, items } = this.state;
    if (error) {
      return <p>Error: {error.message}</p>;
    } else if (!isLoaded) {
      return <p>Loading...</p>;
    } else {
      return (
          <ul>
            {items.map(item => (
              <li key={item.id}>
                {item.name} - {item.category}
				 <button onClick={t() => this.redirectToEdit(item.id)}>Edit</button>
				<button onClick={() => this.deleteProduct(item.id)}>Delete</button>  
              </li>
            ))}
          </ul>
      );
    }
  }
}

class Products extends Component {
  render() {
    return (
      <React.Fragment>
        <h1 className="display-4">Products</h1>
        <ProductList />
        <Validation />
      </React.Fragment>
    );
  }
}
export default Products;
