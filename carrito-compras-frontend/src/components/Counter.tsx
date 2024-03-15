import { FunctionComponent, useState } from "react";
import { Operation } from "../entities/Interfaces";
interface Props {
  removeProductCallback: (productId: number) => void;
  handleUpdateQuantity: (productId: number, operation: Operation) => void;
  productId: number;
  quantity: number;
}
export const Counter: FunctionComponent<Props> = ({
  removeProductCallback,
  handleUpdateQuantity,
  productId,
  quantity
}) => {
  const [value, setValue] = useState<number>(quantity);

  const reduce = (): void => {
    handleUpdateQuantity(productId, "decrease");

    setValue((prevState) => {
      const updatedValue = prevState - 1;
      if (updatedValue === 0) {
        removeProductCallback(productId);
      }
      return updatedValue;
    });
  };

  const increase = (): void => {
    handleUpdateQuantity(productId, "increase");
    setValue((prevState) => prevState + 1);
  };
  // https://www.svgrepo.com/svg/521942/add-ellipse
  return (
    <div className="counter-container">
      <img
        className="counter-button"
        src={process.env.PUBLIC_URL + "/svg/remove-circle.svg"}
        onClick={reduce}
      />
      <span className="counter-label">{value}</span>
      <img
        className="counter-button"
        src={process.env.PUBLIC_URL + "/svg/add-circle.svg"}
        onClick={increase}
      />
    </div>
  );
};
