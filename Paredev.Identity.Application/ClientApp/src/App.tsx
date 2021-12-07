import * as React from "react"
import {
  ChakraProvider
} from "@chakra-ui/react"
import { theme } from './theme';
import { Route, Routes } from 'react-router';
import { Login, SignUp } from './pages'

export const App = () => {
  return (
    <ChakraProvider theme={theme}>
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/sign-up" element={<SignUp />} />
      </Routes>
    </ChakraProvider>
  )
}