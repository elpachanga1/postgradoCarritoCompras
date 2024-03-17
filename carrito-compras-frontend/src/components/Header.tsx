import { ShoppingCartMenu } from './ShoppingCart';
import { AuthMenu } from './Auth';

export const Header = ({ shoppingCart, setShoppingCart }: any) => {
  return (
    <header>
      <h1>Tienda</h1>
      <AuthMenu />
      <ShoppingCartMenu
				shoppingCart={shoppingCart}
				setShoppingCart={setShoppingCart}
      />
    </header>
  );
};
