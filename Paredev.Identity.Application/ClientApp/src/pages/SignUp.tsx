import { Flex } from '@chakra-ui/layout';
import React from 'react';
import { Page } from '../components/layout/Page';

export const SignUp: React.FC = (props) => {
  return <Page>
    <Page.Navbar />
    <Page.Content>
      <Flex>
        Hello world!
      </Flex>
    </Page.Content>
  </Page>
}