'use client'

import InfoNavbar from "@/components/navbar/InfoNavbar"
import { Container, Grid, GridItem, HStack, Icon, Show, Text, useColorMode, VStack } from "@chakra-ui/react"
import Link from "next/link"
import { usePathname, useRouter } from "next/navigation"
import React, { useLayoutEffect} from "react"
import { SlArrowRight } from "react-icons/sl"



function SettingsPage({ children }: { children: React.ReactNode }) {
    const path = usePathname()
    const { push } = useRouter()
    const { colorMode } = useColorMode()
    const settings = '/settings'

    function handleResize() {
        const screen = window.screen.width
        if (path == settings && screen > 767) {

            push('/settings/display')
        }
    }
    useLayoutEffect(() => {

        handleResize()

    })

    

    return (
        <>
            <Container
                w='100%'
                h='100%'
                maxW={['100%','100%','100%','100%','100%','85%','80%']}
                p='0'
            >
                <Grid
                    w='100%'
                    h='100%'
                    templateColumns={['1fr', '1fr', '35% 1fr', '40% 1fr']}
                >
                    <GridItem
                        display={
                            [
                                path == settings ? '' : 'none',
                                path == settings ? '' : 'none',
                                'block',
                                'block'

                            ]
                        }
                        borderRight='1px'
                        borderColor={colorMode == 'light' ? 'gray.100' : 'whiteAlpha.200'}
                    >
                        <VStack align='start' spacing={5}>
                            <Show below="sm">
                                <InfoNavbar back={true} name={'Configuracion'} px="10px" />
                            </Show>
                            <Show above="sm">
                                <InfoNavbar back={false} name={'Configuracion'} px="10px" />
                            </Show>
                            <VStack w='100%' align='start'>
                                <SettingsItem label="Pantalla" link="/settings/display" />
                            </VStack>
                        </VStack>
                    </GridItem>
                    <GridItem
                        display={
                            [
                                path == settings ? 'none' : '',
                                path == settings ? 'none' : '',
                                'block',
                                'block'

                            ]}
                    >
                        {children}
                    </GridItem>
                </Grid>
            </Container >
        </>
    )
}

function SettingsItem({ label, link }: { label: string, link: string }) {
    const { colorMode } = useColorMode()
    const path = usePathname()
    return (
        <>
            <Link href={link} style={{ width: '100%' }}>
                <HStack
                    w='100%'
                    padding='10px'
                    _hover={{
                        background: colorMode == 'light' ? 'gray.100' : 'gray.700'
                    }}
                    background={
                        path == link ?
                            colorMode == 'light' ? 'gray.100' : 'gray.700'
                            : ''
                    }
                    borderRight={path == link ? '2px' : 'none'}
                    borderRightColor='blue.500'
                    alignItems='center'
                    justifyContent='space-between' >
                    <Text fontSize='md' fontWeight='light' >{label}</Text>
                    <Icon as={SlArrowRight} _hover={{ cursor: 'pointer' }} size='sm' boxSize='12px' />
                </HStack>
            </Link>
        </>
    )
}


export default SettingsPage