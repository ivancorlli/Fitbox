'use client'
import {
  Drawer,
  DrawerBody,
  DrawerFooter,
  DrawerOverlay,
  DrawerContent,
  Text,
  useDisclosure,
  IconButton,
  DrawerHeader,
  Divider,
  VStack,
  HStack,
  Icon,
  useColorMode,
} from '@chakra-ui/react'
import Link from 'next/link'
import React from 'react'
import { IconType } from 'react-icons'
import { SlBulb, SlFire, SlFrame, SlMenu, SlSettings, SlSupport } from 'react-icons/sl'
import RegisterButton from '../button/RegisterButton'

export default function Menu() {
  const {toggleColorMode} = useColorMode()
  const { isOpen, onOpen, onClose } = useDisclosure()
  const btnRef = React.useRef<HTMLButtonElement>(null)

  return (
    <>
      <IconButton size='md' 
      aria-label='Open Drawer' 
      ref={btnRef} background='none' 
      onClick={onOpen} icon={<SlMenu />} 
      _pressed={{background:'none'}}
      _hover={{background:'none'}}
      >
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
            <RegisterButton />
          </DrawerHeader>
          <Divider />
          <DrawerBody>
            <NonSessionMenu/>
          </DrawerBody>
          <Divider />
          <DrawerFooter w='95%'>
            <HStack w='100%' justifyContent='space-between'>
              <IconButton aria-label='Change Theme' icon={<SlBulb/>} bg='none' borderRadius='50' onClick={toggleColorMode}/>
              <IconButton aria-label='Open Camera' icon={<SlFrame/>} bg='none' borderRadius='50' />
            </HStack>
          </DrawerFooter>
        </DrawerContent>
      </Drawer>
    </>
  )
}



function NonSessionMenu() {
  const buttons:IMenuButton[] = [
    {
      link:'/',
      name:'Gimnasios',
      icon:SlFire
    },
    {
      link:'/help',
      name:'Ayuda',
      icon:SlSupport
    },
    {
      link:'/configuration',
      name:'Configuracion',
      icon:SlSettings
    }
  ]
  return (
    <>
      <VStack align='start' spacing='5'>
        {
          buttons.map(x=><MenuButton config={x} key={Math.random()}/>)
        }
      </VStack>
    </>
  )
}

interface IMenuButton {
  link: string
  name: string
  icon: IconType
}

function MenuButton({ config }: { config: IMenuButton }) {
  return (
    <>
      <Link href={config.link ?? '/'} style={{ 'width': '80%' }}>
        <HStack w='100%' spacing='5'>
          <Icon as={config.icon} boxSize='6' />
          <Text fontSize='lg' fontWeight='bold' >{config.name}</Text>
        </HStack>
      </Link>
    </>
  )
}











