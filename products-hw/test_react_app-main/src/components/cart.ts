import { IProduct } from "../models";

export const addToCart = (product: IProduct, cart: IProduct[]): IProduct[] => {
    const productIndex = cart.findIndex((p) => p.id === product.id);
  
    if (productIndex === -1) {
      return [...cart, product];
    } else {
      const newCart = [...cart];
      newCart[productIndex] = {
        ...product,
      };
      return newCart;
    }
  };