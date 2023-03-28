import React, { useState } from "react";
import { ProductInfo } from "../components/Product";
import { Link, useParams } from "react-router-dom";
import { products } from "../data/products";
import { Cart } from "./Cart";
import { addToCart } from "../components/cart";
import { IProduct } from "../models";

function ProductList() {
  const { id } = useParams<{ id: string }>();
  const product = products.find((p) => p.id.toString() === id);
  const [cart, setCart] = useState<IProduct[]>([]);

  if (!product) {
    return <div>Продукт не найден</div>;
  }


  const handleAddToCart = (product: IProduct) => {
    const newCart = addToCart(product, cart);
    setCart(newCart);
    localStorage.setItem("cart", JSON.stringify(newCart));
  };

  return (
<div>
<div className="Main">
<h1>Подробнее о товаре</h1>
<ul>
<li>
<Link to="/">Каталог</Link>
</li>
<li>
<Link to="/cart">Корзина ({cart.length})</Link>
</li>
</ul>
</div>
<h2>
<ProductInfo product={product} />
<button onClick={() => handleAddToCart(product)}>Добавить в корзину</button>
</h2>
<Cart cart={cart} setCart={setCart} />
</div>
);
}

export default ProductList;