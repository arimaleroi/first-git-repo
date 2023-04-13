import React from 'react'
import { Link } from 'react-router-dom'
import { IProduct } from '../models'


interface ProductProps {
    product: IProduct
}

export function Product ({product}: ProductProps) {

    return (

                <div className="prod">

                <img src={product.image} className="prodImage" alt={product.title} />
                <p className="titleProduct">{product.title}<br /></p>
                <p className="priceProduct">Цена: {product.price}$</p>
                <Link to={`/product/${product.id}`}>Подробнее</Link>
                </div>

    )
}

export function ProductInfo ({product}: ProductProps) {

    return (

                <div className="prodInfo">

                <img src={product.image} className="prodImage" alt={product.title} />
                <p className="titleProduct">{product.title}<br /></p>
                <p className="priceProduct">Цена: {product.price}$</p>
                <p className="descProduct">{product.description}</p>
                <p className="">Рейтинг: {product.rating.rate}</p>
                </div>

    )
}


