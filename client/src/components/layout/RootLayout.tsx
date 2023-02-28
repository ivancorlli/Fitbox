'use client'
import { Container, Grid, GridItem, Hide, Show } from "@chakra-ui/react"
import React from "react"
import LeftMenu from "../menu/LeftMenu"
import AsideMenu from "../sidebar/AsideMenu"



function RootLayout({ children }: { children: React.ReactNode }) {
    return (
        <>
            <Container w='100%' p='0' maxW={['100%', '100%', '100%', '100%', '95%', '90%']}>
                <Grid
                    w='100%'
                    h='100%'
                    templateColumns={['1fr', '75px 1fr', '75px 1fr', '250px 1fr']}
                    gap='0'
                >
                    <SideBars>
                        <Hide below="sm">
                            <Show below="lg">
                                <LeftMenu />
                            </Show>
                        </Hide>
                        <Hide below="lg">
                            <AsideMenu />
                        </Hide>
                    </SideBars>
                    <Content >
                        {children}
                    </Content>
                </Grid>
            </Container>
        </>
    )
}

function Content({ children }: { children: React.ReactNode }) {
    return (
        <>
            <GridItem w='100%' h='100vh' p='0' className="content">
                {children}
            </GridItem>
        </>
    )
}


function SideBars({ children }: { children: React.ReactNode }) {
    return (
        <>
            <Hide below="sm">
                <GridItem w='100%' h='100vh' position='sticky' top={0} left={0}>
                    {children}
                </GridItem>
            </Hide >

        </>
    )
}

export default RootLayout


