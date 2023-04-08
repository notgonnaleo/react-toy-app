import { useEffect, useState } from 'react';
import { getProducts } from '../../services/Products/productsService';
import { ProductsType } from '../../types/productsType';
import Table from './genericTable';

function ProductTable() {
    const [products, setProducts] = useState<ProductsType[]>([]);

    useEffect(() => {
        async function fetchData() {
            const data = await getProducts();
            setProducts(data);
        }
        fetchData();
    }, []);

    const columns = [
        { title: 'Id', render: (product: ProductsType) => <span>{product.productId}</span> },
        { title: 'Product Name', render: (product: ProductsType) => <span>{product.name}</span> },
    ];

    return <Table data={products} columns={columns} />;
}

export default ProductTable;