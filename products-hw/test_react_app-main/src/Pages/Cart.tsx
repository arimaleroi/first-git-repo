import React, { useEffect } from "react";
import { IProduct } from "../models";

interface Props {
  cart: IProduct[];
  setCart: (cart: IProduct[]) => void;
}

export const Cart: React.FC<Props> = ({ cart, setCart }) => {
  const handleRemoveClick = (productIndex: number) => {
    const newCart = [...cart];
    newCart.splice(productIndex, 1);
    setCart(newCart);
    localStorage.setItem("cart", JSON.stringify(newCart));
  };

  useEffect(() => {
    const savedCart = localStorage.getItem("cart");
    if (savedCart) {
      setCart(JSON.parse(savedCart));
    }
  }, [setCart]);

  return (
    <div>
      <h1>Корзина</h1>
      {cart.map((product, index) => (
        <div key={product.id}>
          <h3>{product.title}</h3>
          <p>{product.description}</p>
          <p>{product.price}</p>
          <button onClick={() => handleRemoveClick(index)}>Remove</button>
        </div>
      ))}
    </div>
  );
};