import { useState } from 'react';
import { Header } from './components/Header';
import { ProductList } from './components/ProductList';
import { ShoppingCart } from './entities/Interfaces';

function App() {
	const voidShoppingCart: ShoppingCart = {
		items: [],
		countProducts: 0,
		total: 0,
	};
	const [shoppingCart, setShoppingCart] = useState(voidShoppingCart);

	return (
		<>
			<Header
				shoppingCart={shoppingCart}
				setShoppingCart={setShoppingCart}
			/>
			<ProductList
				setShoppingCart={setShoppingCart}
			/>
		</>
	);
}

export default App;
