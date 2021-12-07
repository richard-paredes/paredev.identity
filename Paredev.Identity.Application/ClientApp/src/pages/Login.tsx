import React from 'react';
import { Link as ReactRouterLink } from 'react-router-dom';
import {
    Flex,
    Text,
    Stack,
    Divider,
    Button,
    Icon,
    Link,
    Input,
    Checkbox
} from '@chakra-ui/react';

import {
    KeyIcon,
    RightArrowIcon
} from '../components/icons'

export const Login: React.FC = () => {
    return (
        <Flex flexDir="column" flex="1" justify="center" align="center">
            <Flex h="md" rounded="md" justify="space-evenly" align="center" flexDir="column">
                <Flex flexDir="column" justify="center" align="center" h="24">
                    <Text fontSize="2xl">Sign In</Text>
                    <Icon as={KeyIcon} w="24" h="24" p="2.5" fill="paredev.lightGray" />
                </Flex>
                <Flex h="xs" flexDir="column" justify="space-around" align="center" py="5">
                    <Stack spacing="0" color="white">
                        <Input placeholder="Username" variant="outline" bgColor="paredev.olive" border="1px" borderBottom="0.5" borderColor="black" borderBottomRadius="0"></Input>
                        <Input type="password" placeholder="Password" variant="outline" bgColor="paredev.olive" border="1px" borderTop="0.5" borderColor="black" borderTopRadius="0"></Input>
                        <Checkbox pt="5">Keep me signed in</Checkbox>
                    </Stack>
                    <Button size="md" py="8" border="2px" borderColor="paredev.emerald" bgColor="transparent">
                        <Icon as={RightArrowIcon} w="12" h="12" p="1" stroke="paredev.emerald" fill="none" />
                    </Button>
                </Flex>
                <Divider w="56" my="3" opacity="0.1" bgColor="paredev.gray" />
                <Flex h="16" flexDir="column" align="center" justify="space-evenly" textAlign="center">
                    <Link as={ReactRouterLink} to="/forgot-password">
                        <Text>Forgot password?</Text>
                    </Link>
                    <Link as={ReactRouterLink} to="/sign-up">
                        <Text>Create account</Text>
                    </Link>
                </Flex>
            </Flex>
        </Flex>
    )
}