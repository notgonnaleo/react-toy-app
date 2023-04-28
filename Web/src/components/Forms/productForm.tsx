import React, { useState } from 'react';
import { ProductsType } from '../../types/productsType';
import { saveProduct } from '../../services/Products/productsService';
import GenericForm from '../Forms/genericForm';

const ProductForm = () => {
    const [formData] = useState<ProductsType>({
        tenantId: 0,
        productId: 0,
        name: '',
        description: '',
        price: 0,
        productTypeId: 0,
        modifiedBy: 0,
        dateCreated: new Date(),
        active: true,
    });

    const handleSubmit = async (data: ProductsType) => {
        try {
            const response = await saveProduct(data);
            console.log(response);
        } catch (error) {
            console.log(error);
        }
    };

    const fields = [
        { name: 'tenantId', label: 'Tenant ID', type: 'number' },
        { name: 'productId', label: 'Product ID', type: 'number' },
        { name: 'productTypeId', label: 'Product Type ID', type: 'number' },
        { name: 'name', label: 'Name', type: 'text' },
        { name: 'description', label: 'Description', type: 'textarea' },
        { name: 'price', label: 'Price', type: 'number' },
    ] as { name: keyof ProductsType; label: string; type?: 'text' | 'number' | 'textarea' }[];

    return (
        <GenericForm initialValues={{ ...formData }} onSubmit={handleSubmit} fields={fields} />
    );
};

export default ProductForm;
