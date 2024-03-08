import React, { useEffect, useState } from 'react';
import { Product, ProductProps } from '../entities/Interfaces';
import { getProducts } from '../services/ProductService';

export const ProductList = ({
	allProducts,
	setAllProducts,
	countProducts,
	setCountProducts,
	total,
	setTotal,
}: ProductProps) => {
	useEffect(() => {
		const fetchProducts = async () => {
			try {
				const products: Product[] = await getProducts();
				setProducts(products);
			} catch (error) {
				console.error('Error fetching products:', error);
			}
		};
	
		fetchProducts();
	}, []);
	
	const [products, setProducts] = useState<Product[]>([]);
	  
	const onAddProduct = (product: Product) => {
		if (allProducts.find((item: Product) => item.id === product.id)) {
			const products = allProducts.map((item: Product) =>
				item.id === product.id
					? { ...item, quantity: item.availableUnits + 1 }
					: item
			);
			setTotal(total + product.unitPrice * product.availableUnits);
			setCountProducts(countProducts + product.availableUnits);
			return setAllProducts([...products]);
		}

		setTotal(total + product.unitPrice * product.availableUnits);
		setCountProducts(countProducts + product.availableUnits);
		setAllProducts([...allProducts, product]);
	};

	return (
		<div className='container-items'>
			{products.map(product => (
				<div className='item' key={product.id}>
					<figure>
						<img src={product.image} alt={product.name} />
					</figure>
					<div className='info-product'>
						<h2>{product.name}</h2>
						<p className='unitPrice'>${product.unitPrice}</p>
						<button onClick={() => onAddProduct(product)}>
							Añadir al carrito
						</button>
					</div>
				</div>
			))}
		</div>
	);
};
