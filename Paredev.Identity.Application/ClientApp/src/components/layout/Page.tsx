import React from 'react';
import { Flex } from '@chakra-ui/react';
import { PageNavbar } from './PageNavbar';
import { PageContent } from './PageContent';
interface PageProps {

}

type IPage = React.FC<PageProps> & {
    Navbar: typeof PageNavbar;
    Content: typeof PageContent;

}

export const Page: IPage = ({ children }) => {
    return (
        <Flex flexDir="column" w="full" h="100vh" bgColor="paredev.black" color="paredev.lightGray">
            {children}
        </Flex>
    );
};

Page.Navbar = PageNavbar;
Page.Content = PageContent;