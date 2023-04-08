import React, { useEffect, useState } from 'react';
import { TableProps } from '../../types/tableType';

function Table<T>({ data, columns }: TableProps<T>) {
    return (
        <table>
            <thead>
                <tr>
                    {columns.map((column) => (
                        <th key={column.title}>{column.title}</th>
                    ))}
                </tr>
            </thead>
            <tbody>
                {data.map((item, index) => (
                    <tr key={index}>
                        {columns.map((column) => (
                            <td key={column.title}>{column.render(item)}</td>
                        ))}
                    </tr>
                ))}
            </tbody>
        </table>
    );
}

export default Table;