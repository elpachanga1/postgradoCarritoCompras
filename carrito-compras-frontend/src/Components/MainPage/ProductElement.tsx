import React from "react";
import { Link } from "react-router-dom";

export const ProductElement: React.FC<any> = (props) => {
    const {product} = props;
    return (
        <li
            data-categoria={product.name}
            className="list-group-item d-flex justify-content-between align-items-center"
        >
        <div className="row p-1">
            <div className="col-xl-3 col-lg-4 col-xs-5">
            <img
                className="p-3 rounded mx-auto d-block"
                src={`${"links.images_api_w200"}/${product.name}`}
                alt="imagen"
            />
            </div>

            <div className="col-xl-7 col-lg-6 col-xs-5">
            <h4>{product.name}</h4>
            <p className="text-justify">
                <span className="font-weight-bold">
                Average: {product?.unitPrice || 0}
                </span>
                <br />
                {product?.description || ""}
            </p>
            </div>

            <div className="col-xl-2 col-lg-2 col-xs-2 align-self-center">
            <Link
                to={`/products/${product.id}`}
                className="btn btn-info mr-2 rounded mx-auto d-block"
            >
                See More
            </Link>
            </div>
        </div>
        </li>
    );
}
