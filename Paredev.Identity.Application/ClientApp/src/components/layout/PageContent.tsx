import React from 'react';
import { Flex } from '@chakra-ui/react';


export const PageContent: React.FC = ({ children }) => {
    return (
        <Flex flexDir="column" flex="1" justify="center" align="center">
            {children}
        </Flex>
    )
}