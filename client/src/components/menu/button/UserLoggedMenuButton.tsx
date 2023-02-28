'use client'

import { Avatar, HStack, Text, VStack } from "@chakra-ui/react"
import { useSession } from "next-auth/react"
import { useEffect, useState } from "react"



export default function UserLoggedMenuButton() {
    const [image,setImage] = useState<string>()
    const { data: session } = useSession()

    useEffect(()=>{
        if(session)
        {
          if(session.user)
          {
            if(session.user.image)
            {
              setImage(session.user.image)
            }
          }
        }else{
          setImage('https://chakra-ui.com/docs/components/avatar')
        }
      },[session])

    return (
        <>
            <VStack alignItems='start'>
                <HStack alignItems='center' spacing={5}>
                    <Avatar
                        size='md'
                        // onClick={onOpen}
                        _hover={{ cursor: 'pointer' }}
                        src={image}
                    />
                    <VStack
                    alignItems='start'
                    >
                        <Text p='0' m='0' as='sub'>
                            {session?.user?.name}
                        </Text>
                        <Text fontSize='xs' >
                           @username
                        </Text>
                    </VStack>
                </HStack>
            </VStack>
        </>
    )
}