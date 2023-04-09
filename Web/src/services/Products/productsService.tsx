import React from 'react';
import axios from 'axios';
import { ProductsAPI } from '../../env';
import { ProductsType } from '../../types/productsType';


export async function getProducts(): Promise<ProductsType[]> {
    try {
        const response = await axios.get(`${ProductsAPI}/GetProducts`);
        return response.data;
    } catch (err) {
        console.log(err);
        return [];
    }
};

export async function getProduct(tenantId: number, productId: number): Promise<ProductsType[]> {
    try {
        const response = await axios.get(`${ProductsAPI}/GetProduct/?TenantId=${tenantId}&ProductId=${productId}`);
        return response.data;
    } catch (err) {
        console.log(err);
        return [];
    }
};

export async function saveProduct(product: ProductsType): Promise<ProductsType[]> {
    try {
        const response = await axios.post(`${ProductsAPI}/CreateProduct`, { product });
        return response.data;
    } catch (err) {
        console.log(err);
        return [];
    }
};


