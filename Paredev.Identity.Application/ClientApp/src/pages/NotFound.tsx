import React from 'react';
import {
    Flex,
    Text,
    Button
} from '@chakra-ui/react'
import { useNavigate } from 'react-router';

export const NotFound: React.FC = () => {
    const navigate = useNavigate();

    const onClick = () => navigate(-1);

    return (
        <Flex>
            <Text fontSize="4xl">
                Whoops!
            </Text>
            <Text fontSize="xl">
                That page doesn't exist.
                <Button onClick={onClick}>Go back</Button>
            </Text>
        </Flex>
    )
}