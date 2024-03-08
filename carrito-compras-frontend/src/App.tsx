import { useState } from 'react';
import { Header } from './components/Header';
import { ProductList } from './components/ProductList';
import { Product } from './entities/Interfaces';

function App() {
  const voidProduct: Product[] = [];
	const [allProducts, setAllProducts] = useState(voidProduct);
	const [total, setTotal] = useState(0);
	const [countProducts, setCountProducts] = useState(0);

	return (
		<>
			<Header
				allProducts={allProducts}
				setAllProducts={setAllProducts}
				total={total}
				setTotal={setTotal}
				countProducts={countProducts}
				setCountProducts={setCountProducts}
			/>
			<ProductList
				allProducts={allProducts}
				setAllProducts={setAllProducts}
				total={total}
				setTotal={setTotal}
				countProducts={countProducts}
				setCountProducts={setCountProducts}
			/>
		</>
	);
}

export default App;
