import { useEffect, useState } from 'react';
import { ComponentProps, Item, ShoppingCart } from '../entities/Interfaces';
import * as ItemService from '../services/ItemService';
import * as CartService from '../services/CartService';
import * as ShoppingCartUtils from '../utils/ShoppingCartUtils';

export const Header = ({
	shoppingCart,
	setShoppingCart,
}: ComponentProps) => {
	const [active, setActive] = useState(false);

	useEffect(() => {
		const fetchItems = async () => {
			try {
				const shoppingCart: ShoppingCart = await ShoppingCartUtils.getShoppingCart();
				setShoppingCart(shoppingCart);
			} catch (error) {
				console.error('Error fetching items:', error);
			}
		};
	
		fetchItems();
	}, []);

	const onDeleteProduct = async (item: Item) => {
		const items = await ItemService.getItemsByProductId(item.idProduct);

		// cambiar por estrategia de subtotal
		let subTotal = 0;
		setShoppingCart({
			items,
			countProducts: shoppingCart.countProducts - items.length,
			total: subTotal
		});
	};

	const onCleanCart = async () => {
		await CartService.EmptyShoppingCart();
		setShoppingCart({
			items: [],
			countProducts: 0,
			total: 0
		});
	};

	return (
		<header>
			<h1>Tienda</h1>

			<div className='container-icon'>
				<div
					className='container-cart-icon'
					onClick={() => setActive(!active)}
				>
					<svg
						xmlns='http://www.w3.org/2000/svg'
						fill='none'
						viewBox='0 0 24 24'
						strokeWidth='1.5'
						stroke='currentColor'
						className='icon-cart'
					>
						<path
							strokeLinecap='round'
							strokeLinejoin='round'
							d='M15.75 10.5V6a3.75 3.75 0 10-7.5 0v4.5m11.356-1.993l1.263 12c.07.665-.45 1.243-1.119 1.243H4.25a1.125 1.125 0 01-1.12-1.243l1.264-12A1.125 1.125 0 015.513 7.5h12.974c.576 0 1.059.435 1.119 1.007zM8.625 10.5a.375.375 0 11-.75 0 .375.375 0 01.75 0zm7.5 0a.375.375 0 11-.75 0 .375.375 0 01.75 0z'
						/>
					</svg>
					<div className='count-products'>
						<span id='contador-productos'>{shoppingCart.countProducts}</span>
					</div>
				</div>

				<div
					className={`container-cart-products ${
						active ? '' : 'hidden-cart'
					}`}
				>
					{shoppingCart.items.length ? (
						<>
							<div className='row-product'>
								{shoppingCart.items.map((item: Item) => (
									<div className='cart-product' key={item.id}>
										<div className='info-cart-product'>
											<span className='cantidad-producto-carrito'>
												{item.quantity}
											</span>
											<p className='titulo-producto-carrito'>
												{item.idProduct}
											</p>
											<span className='precio-producto-carrito'>
												${item.totalPrice}
											</span>
										</div>
										<svg
											xmlns='http://www.w3.org/2000/svg'
											fill='none'
											viewBox='0 0 24 24'
											strokeWidth='1.5'
											stroke='currentColor'
											className='icon-close'
											onClick={() => onDeleteProduct(item)}
										>
											<path
												strokeLinecap='round'
												strokeLinejoin='round'
												d='M6 18L18 6M6 6l12 12'
											/>
										</svg>
									</div>
								))}
							</div>

							<div className='cart-total'>
								<h3>Total:</h3>
								<span className='total-pagar'>${shoppingCart.total}</span>
							</div>

							<button className='btn-clear-all' onClick={onCleanCart}>
								Vaciar Carrito
							</button>
						</>
					) : (
						<p className='cart-empty'>El carrito está vacío</p>
					)}
				</div>
			</div>
		</header>
	);
};
