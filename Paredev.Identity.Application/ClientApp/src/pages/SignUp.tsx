import React from 'react';
import {
  Flex,
  Link
} from '@chakra-ui/layout';
import { Link as ReactRouterLink } from 'react-router-dom';

export const SignUp: React.FC = (props) => {
  return (
    <Flex>
      Hello sign up!
      <br />
      <Link as={ReactRouterLink} to="/">Log in</Link>
      <br/>
      <Link as={ReactRouterLink} to="/forgot-password">Forgot password?</Link>
    </Flex>
  )
}