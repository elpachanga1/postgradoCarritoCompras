import React, { Component } from "react";
import Swal from "sweetalert2";
import * as ProductService from "../../Services/ProductService";
import { Product } from "../../Entities/Interfaces";
import { ProductList } from "./ProductList";

interface State {
  products: Product[];
}

export class MainPageComponent extends Component<{}, State> {
  constructor(props: any) {
    super(props);
    this.state = {
      products: [],
    };
  }

  async componentDidMount() {
    const products: Product[] = await ProductService.getProducts();
    this.setState({ products });
  }

  render() {
    const { products } = this.state;
    return (
      <div>
        <h1 className="text-center">Movie Portal</h1>
        <ProductList products={products}/>
      </div>
    );
  }
}