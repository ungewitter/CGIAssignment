<script setup lang="ts">
import { useStore } from '../stores/businessCardStore'
import BusinessCardComponentVue from '../components/BusinessCardComponent.vue'
import { computed, onMounted } from 'vue'
import { config } from '@/config'

const cardStore = useStore()
const businessCardList = computed(() => cardStore.businessCardList)

onMounted(() => {
  cardStore.getBusinessCards()
})
</script>

<template>
  <div class="about">
    <h1>Alla visitkort</h1>
    <div v-for="card in businessCardList" :key="card.id">
      <BusinessCardComponentVue
        :cardId="card.id"
        :firstName="card.firstName"
        :lastName="card.lastName"
        :phoneNumber="card.phoneNumber"
        :email="card.email"
        :imageUrl="`${config.apiUrl}/${card.imageFilePath}`"
      ></BusinessCardComponentVue>
    </div>
  </div>
</template>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 80vh;
    display: flex;
    flex-direction: column;
    flex-wrap: nowrap;
    align-items: center;
  }
}
</style>
