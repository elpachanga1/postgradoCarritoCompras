import React, { Fragment } from "react";
import { Product } from "../../Entities/Interfaces";
import { ProductElement } from "./ProductElement";

export const ProductList = (props: any) => {
  const mapProducts = () =>
    props.products.map((product: Product) => <ProductElement key={product.id} product={product} />);

  return (
    <Fragment>
      <ul className="list-group mt-5">{mapProducts()}</ul>
    </Fragment>
  );
};
