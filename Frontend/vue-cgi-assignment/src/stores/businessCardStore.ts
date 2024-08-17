import { defineStore } from 'pinia'
import {
  getApiRequest,
  getByIdApiRequest,
  postApiRequest,
  removeApiRequest,
  updateApiRequest
} from '@/services/businessCardService'

export const useStore = defineStore('store', {
  state: () => ({
    businessCardList: [] as BusinessCard[]
  }),
  actions: {
    async getBusinessCards() {
      this.businessCardList = await getApiRequest()
    },
    async getBusinessCardById(id: string) {
      return await getByIdApiRequest(id)
    },
    async addBusinessCard(data: FormData) {
      return await postApiRequest(data)
    },
    async removeBusinessCard(id: string) {
      return await removeApiRequest(id)
    },
    async updateBusinessCard(id: string, data: FormData) {
      return await updateApiRequest(id, data)
    }
  }
})
