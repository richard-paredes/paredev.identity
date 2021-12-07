import * as React from "react"
import {
  ChakraProvider
} from "@chakra-ui/react"
import { theme } from './theme';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { Login, NotFound, SignUp } from './pages'
import { AppLayout } from "./components/layout/AppLayout";
import { ForgotPassword } from "./pages/ForgotPassword";

export const App = () => {
  return (
    <ChakraProvider theme={theme}>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<AppLayout />}>
            <Route index element={<Login />} />
            <Route path="/sign-up" element={<SignUp />} />
            <Route path="/forgot-password" element={<ForgotPassword />} />
            <Route path="*" element={<NotFound />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </ChakraProvider>
  )
}