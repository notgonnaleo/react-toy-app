import React, { useState } from 'react';

type FormProps<T> = {
    initialValues: T;
    onSubmit: (data: T) => Promise<void>;
    fields: {
        name: keyof T;
        label: string;
        type?: 'text' | 'number' | 'textarea';
    }[];
};

function GenericForm<T>({ initialValues, onSubmit, fields }: FormProps<T>) {
    const [formData, setFormData] = useState<T>(initialValues);

    const handleChange = (event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = event.target;
        setFormData((prevFormData) => ({
            ...prevFormData,
            [name]: value,
        }));
    };

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        try {
            await onSubmit(formData);
        } catch (error) {
            console.log(error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            {fields.map((field) => (
                <div key={String(field.name)}>
                    <label htmlFor={String(field.name)}>{field.label}:</label>
                    {field.type === 'textarea' ? (
                        <textarea name={String(field.name)} value={formData[field.name] as any} onChange={handleChange} />
                    ) : (
                        <input type={field.type || 'text'} name={String(field.name)} value={formData[field.name] as any} onChange={handleChange} />
                    )}

                </div>
            ))}
            <button type="submit">Submit</button>
        </form>
    );
}

export default GenericForm;
