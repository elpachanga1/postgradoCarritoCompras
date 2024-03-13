import { useEffect, useState } from 'react';
import { ComponentProps, Product, ShoppingCart } from '../entities/Interfaces';
import * as CartService from '../services/CartService';
import * as ProductService from '../services/ProductService';
import * as ShoppingCartUtils from '../utils/ShoppingCartUtils';

export const ProductList = ({
	shoppingCart,
	setShoppingCart,
}: ComponentProps) => {
	useEffect(() => {
		const fetchProducts = async () => {
			try {
				const products: Product[] = await ProductService.getProducts();
				setProducts(products);
			} catch (error) {
				console.error('Error fetching products:', error);
			}
		};
	
		fetchProducts();
	}, []);
	
	const [products, setProducts] = useState<Product[]>([]);
	  
	const onAddProduct = async (product: Product) => {
		await CartService.addProductToShoppingCart(product);
		const shoppingCart: ShoppingCart = await ShoppingCartUtils.getShoppingCart();
		setShoppingCart(shoppingCart);
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
