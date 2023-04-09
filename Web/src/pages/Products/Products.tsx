import ProductTable from '../../components/Datatables/productTable';
import ProductForm from '../../components/Forms/productForm';

function Products() {
    return (
        <>
            <h1>Products</h1>
            <ProductTable />
            <ProductForm />
        </>
    );
}

export default Products;
