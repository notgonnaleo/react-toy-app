import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import ProductTable from './components/Datatables/productTable';

function App() {
    return (
        <>
            <h1>UI Prototype</h1>
            <ProductTable />
        </>
    );
}

export default App;
