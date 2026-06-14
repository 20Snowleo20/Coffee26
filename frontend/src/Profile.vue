<script setup>
import { useRouter } from 'vue-router'

const router = useRouter()
import { computed } from 'vue'

const user = computed(
    () =>
        localStorage.getItem('user')
)

function logout() {

    localStorage.removeItem('user')
    localStorage.removeItem('token')

    router.push('/')
}
</script>

<template>

    <div class="p-5">

        <div v-if="user">

            <h1 class="text-2xl">
                Вы успешно авторизованы
            </h1>

            <p class="mt-3">
                Пользователь:
                {{ user }}
            </p>

            <button
                @click="logout"
                class="border px-4 py-2 mt-4"
            >
                Выйти
            </button>

        </div>

        <div v-else>

            <h1 class="text-2xl">
                Вы не авторизованы
            </h1>

        </div>

    </div>

</template>