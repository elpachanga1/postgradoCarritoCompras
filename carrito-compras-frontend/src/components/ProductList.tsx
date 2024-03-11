import React, { useEffect, useState } from 'react';
import { Product, ProductProps } from '../entities/Interfaces';
import { getProducts } from '../services/ProductService';
import { addProductToShoppingCart } from '../services/CartService';

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
	  
	const onAddProduct = async (product: Product) => {
		let products: Product[] = [];
		if (allProducts.find((item: Product) => item.id === product.id)) {
			products = allProducts.map((item: Product) =>
				item.id === product.id
					? { ...item, quantity: item.availableUnits + 1 }
					: item
			);
			await addProductToShoppingCart(product);
			setTotal(total + product.unitPrice);
			setCountProducts(countProducts + 1);
			return setAllProducts([...products]);
		}

		await addProductToShoppingCart(product);
		setTotal(total + product.unitPrice);
		setCountProducts(countProducts + 1);
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
