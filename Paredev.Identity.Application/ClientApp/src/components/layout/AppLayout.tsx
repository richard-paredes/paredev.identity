import React from 'react';
import { Page } from './Page';
import { Outlet } from 'react-router-dom';

export const AppLayout: React.FC = () => {
    return (
        <Page>
            <Page.Navbar />
            <Page.Content>
                <Outlet />
            </Page.Content>
        </Page>
    )
}