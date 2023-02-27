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
  Avatar,
} from '@chakra-ui/react'
import Link from 'next/link'
import { usePathname} from 'next/navigation'
import React, { useEffect, useState } from 'react'
import { IconType } from 'react-icons'
import { SlBulb, SlFire, SlFrame, SlSettings, SlSupport } from 'react-icons/sl'
import RegisterButton from '../button/RegisterButton'

function Menu() {
  const {toggleColorMode} = useColorMode()
  const { isOpen, onOpen, onClose } = useDisclosure()
  const btnRef = React.useRef<HTMLButtonElement>(null)

  return (
    <>
      <Avatar
      size='sm'
      ref={btnRef}  
      onClick={onOpen}
      _hover={{cursor:'pointer'}}
      src='https://chakra-ui.com/docs/components/avatar'
      />
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
  const path = usePathname()

  function handleActive()
  {
    let response = ''
    if(path!=null)
    {
      if(path=='/') response = '/'
      const child = path.split('/')
      if(child)
      {
        response =`/${child[1].toString()}`
      } else{
        response = '/'
      }
    }else{
      response = ''
    }
    return response
  }
  
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
      link:'/settings',
      name:'Configuracion',
      icon:SlSettings
    }
  ]
  return (
    <>
      <VStack w='100%' align='start' spacing='5'>
        {
          buttons.map((x,idx)=><MenuButton config={x} key={idx} active={ handleActive() == x.link ? true :false}/>)
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

function MenuButton({ config,active }: { config: IMenuButton,active:boolean }) 
{
  const {colorMode} = useColorMode()
  return (
    <>
      <Link href={config.link ?? '/'} style={{ 'width': '95%' }}>
        <HStack w='100%'
        paddingY='5px'
        borderRadius='2px' 
        color={active ? 'blue.500':''}
        _hover={{background: colorMode == 'light' ? 'gary.700': 'gray.700', borderRadius:'15px',paddingX:'5px'}}
        >
          <Icon as={config.icon} boxSize='6' />
          <Text fontSize='lg' fontWeight='bold' >{config.name}</Text>
        </HStack>
      </Link>
    </>
  )
}








export {
  NonSessionMenu
}
export default Menu

