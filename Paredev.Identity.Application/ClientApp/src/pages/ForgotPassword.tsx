import React from 'react';
import {
    Flex,
    Link
} from '@chakra-ui/react';
import { Link as ReactRouterLink } from 'react-router-dom';

export const ForgotPassword: React.FC = () => {
    return (
        <Flex flexDir="column" justify="center" align="center">
            Hello forgot password!
            <Link as={ReactRouterLink} to="/">Log in</Link>

            <Link as={ReactRouterLink} to="/sign-up">Need an account?</Link>
        </Flex>
    )
}