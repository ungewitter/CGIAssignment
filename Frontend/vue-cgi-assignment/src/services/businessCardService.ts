import { config } from '@/config'

export const getApiRequest = async (): Promise<BusinessCard[]> => {
  try {
    const response = await fetch(`${config.apiUrl}/api/BusinessCard`, {
      method: 'GET'
    })

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`)
    }

    const data: BusinessCard[] = await response.json()
    return data
  } catch (error) {
    console.log('Error:', error)
    return []
  }
}

export const getByIdApiRequest = async (id: string): Promise<BusinessCard> => {
  try {
    const response = await fetch(`${config.apiUrl}/api/BusinessCard/${id}`, {
      method: 'GET'
    })

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`)
    }

    const data: BusinessCard = await response.json()
    return data
  } catch (error) {
    console.log('Error:', error)
    return {} as BusinessCard
  }
}

export const postApiRequest = async (formData: FormData): Promise<BusinessCard> => {
  try {
    const response = await fetch(`${config.apiUrl}/api/BusinessCard`, {
      method: 'POST',
      body: formData
    })

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`)
    }

    const data: BusinessCard = await response.json()
    return data
  } catch (error) {
    console.log('Error:', error)
    return { firstName: 'Fel' } as BusinessCard
  }
}

export const removeApiRequest = async (id: string): Promise<BusinessCard> => {
  try {
    const response = await fetch(`${config.apiUrl}/api/BusinessCard/delete/${id}`, {
      method: 'DELETE'
    })

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`)
    }

    const data: BusinessCard = await response.json()
    return data
  } catch (error) {
    console.log('Error:', error)
    return { firstName: 'Fel' } as BusinessCard
  }
}

export const updateApiRequest = async (id: string, formData: FormData): Promise<BusinessCard> => {
  try {
    const response = await fetch(`${config.apiUrl}/api/BusinessCard/update/${id}`, {
      method: 'PUT',
      body: formData
    })

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`)
    }

    const data: BusinessCard = await response.json()
    return data
  } catch (error) {
    console.log('Error:', error)
    return { firstName: 'Fel' } as BusinessCard
  }
}
