import React from 'react';
import { Formik, Form, Field, FormikHelpers, FieldProps } from 'formik';
import { FormControl, FormLabel, Input, FormErrorMessage, Button } from '@chakra-ui/react'

interface ILoginRequest {
    username: string;
    password: string;
}

const initialValues: ILoginRequest = {
    username: "",
    password: ""
}

interface FormInputProps extends FieldProps {
    placeholder: string;
}

export const LoginForm: React.FC = () => {
    function handleSubmit(values: ILoginRequest, actions: FormikHelpers<ILoginRequest>) {
        setTimeout(() => {
            alert(JSON.stringify(values, null, 2))
            actions.setSubmitting(false)
        }, 1000)
    }

    return (
        <Formik
            initialValues={initialValues}
            onSubmit={handleSubmit}
        >
            {({ isSubmitting }) => (
                <Form>
                    <Field name="username">
                        {({ field, form }: FormInputProps) => (
                            <FormControl isInvalid={!!form.errors.name && !!form.touched.name} isRequired>
                                <FormLabel htmlFor="username">Username</FormLabel>
                                <Input {...field} variant="flushed" id="username" placeholder="Username" />
                                <FormErrorMessage>{form.errors.name}</FormErrorMessage>
                            </FormControl>
                        )}
                    </Field>
                    <Field name="password">
                        {({ field, form }: FormInputProps) => (
                            <FormControl isInvalid={!!(form.errors.name && form.touched.name)} isRequired>
                                <FormLabel htmlFor="password">Password</FormLabel>
                                <Input {...field} variant="flushed" type="password" id="password" placeholder="Password" />
                                <FormErrorMessage>{form.errors.name}</FormErrorMessage>
                            </FormControl>
                        )}
                    </Field>
                    <Button
                        mt={4}
                        colorScheme="teal"
                        isLoading={isSubmitting}
                        type="submit"
                    >
                        Submit
                    </Button>
                </Form>
            )}
        </Formik>
    )
}