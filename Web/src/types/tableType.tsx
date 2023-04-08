export interface TableColumn<T> {
    title: string;
    render: (item: T) => JSX.Element;
}

export interface TableProps<T> {
    data: T[];
    columns: TableColumn<T>[];
}
