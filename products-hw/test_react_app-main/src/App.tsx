import React, { useState } from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { IProduct } from "./models";
import { Cart } from "./Pages/Cart";
import MainPage from "./Pages/MainPage";
import ProductList from "./Pages/ProductList";


const App = () => {

  const [cart, setCart] = useState<IProduct[]>([]);

  return (
    <div className="container">
      
    <BrowserRouter>
    <Routes>
    <Route path="/" element={<MainPage />}></Route>
    <Route path="/product/:id" element={<ProductList />}></Route>
    <Route
            path="/cart"
            element={<Cart cart={cart} setCart={setCart} />}
          ></Route>


    </Routes>
    </BrowserRouter>



    
    </div>
  );
};

export default App;