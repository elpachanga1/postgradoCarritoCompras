import { useState, useEffect } from 'react';
import { ShoppingCart } from '../entities/Interfaces';
import { Header } from './Header';
import { ProductList } from './ProductList';
import { isEmpty} from 'lodash';
import { useNavigate } from 'react-router';

function Home() {
	const voidShoppingCart: ShoppingCart = {
		items: [],
		countProducts: 0,
		total: 0,
	};
	const [shoppingCart, setShoppingCart] = useState(voidShoppingCart);
    const navigate = useNavigate();
    useEffect(() => {
        const userLogged = JSON.parse(localStorage.getItem('userLogged') || '{}');
        if(isEmpty(userLogged)) {
            navigate('/login');
        }
    }, [])
	return (
		<div className='text-center'>
			<h1>Now, you can do orders</h1>
		</div>
	);
}

export default Home;
