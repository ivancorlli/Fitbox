'use client'
import {
    Drawer,
    DrawerBody,
    DrawerFooter,
    DrawerOverlay,
    DrawerContent,
    Text,
    Button,
    useDisclosure,
    IconButton,
    DrawerHeader,
    Divider,
    VStack,
    HStack,
    Icon,
  } from '@chakra-ui/react'
import Link from 'next/link'
import React from 'react'
import {SlBulb, SlFire, SlFrame, SlMenu, SlSettings, SlSupport} from 'react-icons/sl'

export default function Menu()
{

    const {isOpen,onOpen,onClose} = useDisclosure()
    const btnRef = React.useRef<HTMLButtonElement>(null)

    return(
        <>
        <IconButton aria-label='Open Drawer' ref={btnRef} background='none' onClick={onOpen} icon={<SlMenu/>}>
        Open
        </IconButton>
        <Drawer
        isOpen={isOpen}
        placement='left'
        onClose={onClose}
        finalFocusRef={btnRef}
      >
        <DrawerOverlay />
        <DrawerContent>
          <DrawerHeader>
            <VStack align='start'>
            <Button maxW='95%' w='100%' bg='blue.400' color='white'>
                Iniciar Sesion
            </Button>
            <Button maxW='95%' w='100%' variant='outline'  color='cyan.400' borderColor='cyan.400'>
                Registrarse
            </Button>
            </VStack>
          </DrawerHeader>
            <Divider/>
          <DrawerBody>
            <VStack align='start' spacing='5'>
            <Link href='/' style={{'width':'80%'}}>
                <HStack w='100%' spacing='5'>
                    <Icon as={SlFire} boxSize='6'/>
                    <Text fontSize='lg'fontWeight='bold' >Gimnasios</Text>
                </HStack>
            </Link>
            <Link href='/' style={{'width':'80%'}}>
                <HStack w='100%' spacing='5'>
                    <Icon as={SlSupport} boxSize='6'/>
                    <Text fontSize='lg'fontWeight='bold' >Ayuda</Text>
                </HStack>
            </Link>
            <Link href='/' style={{'width':'80%'}}>
                <HStack w='100%' spacing='5'>
                    <Icon as={SlSettings} boxSize='6'/>
                    <Text fontSize='lg'fontWeight='bold' >Configuracion</Text>
                </HStack>
            </Link>

            </VStack>
          </DrawerBody>
            <Divider/>
          <DrawerFooter w='95%'>
            <HStack w='100%' justifyContent='space-between'>
                <Icon as={SlBulb} boxSize='5'/>
                <Icon as={SlFrame} boxSize='5'/>
            </HStack>
          </DrawerFooter>
        </DrawerContent>
      </Drawer>
    </>
    )
}