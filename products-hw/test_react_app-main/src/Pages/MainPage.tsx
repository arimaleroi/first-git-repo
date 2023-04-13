import React, { useState } from "react";
import { Product } from "../components/Product";
import { Link } from "react-router-dom";
import { products } from "../data/products";
import { addToCart } from "../components/cart";
import { IProduct } from "../models";

function MainPage() {
  const [cart, setCart] = useState<IProduct[]>([]);

  
  const handleAddToCart = (product: IProduct) => {
    const newCart = addToCart(product, cart);
    setCart(newCart);
    localStorage.setItem("cart", JSON.stringify(newCart));
  };

  return (
    <div className="Main">
      <h1>Интернет-магазин</h1>
      <ul>
        <li>
          <Link to="/">Каталог</Link>
        </li>
        <li>
          <Link to="/cart">Корзина ({cart.length})</Link>
        </li>
      </ul>

      <div className="Products">
        {products.map((product) => (
          <div key={product.id}>
            <Product product={product} />
            <button onClick={() => handleAddToCart(product)}>Add to cart</button>
          </div>
        ))}
      </div>
    </div>
  );
}

export default MainPage;