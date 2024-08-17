<script setup lang="ts">
defineProps<{
  label: string
  modelValue: string
  isRequired: boolean
}>()

const emit = defineEmits<{
  (e: 'update:modelValue', value: string): void
}>()

const handleInput = (event: Event) => {
  const input = event.target as HTMLInputElement
  emit('update:modelValue', input.value)
}
</script>

<template>
  <label>{{ label }}</label>
  <input :required="isRequired" :value="modelValue" type="text" @input="handleInput" />
</template>

<style></style>
