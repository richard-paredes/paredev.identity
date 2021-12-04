import * as React from "react"
import {
  ChakraProvider,
  Box,
  Flex,
  Stack,
  Input,
  Checkbox,
  Divider,
  Text,
  Link,
  Icon
} from "@chakra-ui/react"
import { theme } from './theme';
import { KeyIcon } from "./Logo";

export const App = () => {
  return (
    <ChakraProvider theme={theme}>
      <Flex justify="center" align="center" h="100vh" bg="paredev.black">
        <Flex w="container.md" h="md" rounded="md" justify="space-evenly" align="center" flexDir="column">
          <Box w="24" h="24" borderRadius="5px" border="2px" borderColor="paredev.emerald" bgColor="rgba(167,243,208,0.25)">
            <Icon as={KeyIcon} w="24" h="24" p="2.5" fill="paredev.emerald" />
          </Box>
          <Box py="5">
            <Stack spacing="0" color="white">
              <Input placeholder="Username" variant="outline" bgColor="rgba(228, 288, 231, 0.25)" border="1px" borderBottom="0.5" borderColor="black" borderBottomRadius="0"></Input>
              <Input type="password" placeholder="Password" variant="outline" bgColor="rgba(228, 288, 231, 0.25)" border="1px" borderTop="0.5" borderColor="black" borderTopRadius="0"></Input>
            </Stack>
            <Checkbox pr="4" pt="4" color="white">Keep me signed in</Checkbox>
          </Box>
          <Box textAlign="center">
            <Divider w="56" my="3" opacity="0.1"/>
            <Link href="#">
              <Text color="white">Forgot password?</Text>
            </Link>
          </Box>
        </Flex>
      </Flex>
    </ChakraProvider>
  )
}